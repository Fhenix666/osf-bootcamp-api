using BootCamp.Adm.Entities;
using BootCamp.Adm.Manager.Interfaces;
using BootCamp.Adm.Repository.Interfaces;
using BootCamp.Adm.Security;
using BootCamp.Adm.Settings;
using BootCamp.Adm.ViewModels.Input;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BootCamp.Adm.IRepository;

namespace BootCamp.Adm.Manager
{

    public class SecurityManager : ISecurityManager
	{
        readonly ApiConfigSettings _apiConfigSettings;

		private const string MOBILE = "MOBILE";
		readonly JwtSetting _jwtSetting;
		readonly IUserManager _userManager;
		readonly IUserRepository _userRepository;


		public SecurityManager(
            IOptions<ApiConfigSettings> apiConfigSettingsOpt,
			IOptions<JwtSetting> jwtSettingOpt,
			IUserManager userManager,
			IUserRepository userRepository
			)
		{
            _apiConfigSettings = apiConfigSettingsOpt.Value;
			_jwtSetting = jwtSettingOpt.Value;
			_userManager = userManager;
			_userRepository = userRepository;
		}


		public async Task<SecurityInfo> GetSecurityInfo(InputCredentialsViewModel credentials)
		{
			SecurityInfo securityInfo = new SecurityInfo();
			User user = await _userRepository.GetByEmail(credentials.Email);
			if (user == null)
				throw new Exception("Credenciales invalidas");

			var userInfo = await _userManager.GetById(user.Id);

			if (!userInfo.Active)
			{
				throw new Exception("Acceso denegado");
			}

			string passwordHash = HashHelper.GetHash(_apiConfigSettings.SecuritySalt, credentials.Password);

			if (user != null && user.PasswordHash == passwordHash)
			{
				byte[] key = Encoding.ASCII.GetBytes(_jwtSetting.Secret);
				securityInfo.User = userInfo;
				securityInfo.Token = GenJwt(user.Id.ToString(), key, null, _jwtSetting.TimeLifeInDays);
				//securityInfo.PermissionList = _permissionRepository.GetByProfileId(user.ProfileFK);
			}
			else
			{
				throw new Exception("El correo o contraseña es incorrecta");
			}

			return securityInfo;
		}


		public async Task<SecurityInfo> GetSecurityMobileInfo(InputCredentialsViewModel credentials)
		{
			SecurityInfo securityInfo = new SecurityInfo();
			User user = await _userRepository.GetByEmail(credentials.Email);
			if (user == null)
				throw new Exception("Credenciales invalidas");

			var userInfo = await _userManager.GetById(user.Id);

			string passwordHash = HashHelper.GetHash(_apiConfigSettings.SecuritySalt, credentials.Password);

			if (user != null && user.PasswordHash == passwordHash)
			{
				byte[] key = Encoding.ASCII.GetBytes(_jwtSetting.Secret);
				securityInfo.User = userInfo;
				securityInfo.Token = GenJwt(user.Id.ToString(), key, null, _jwtSetting.TimeLifeInDays);
				//securityInfo.PermissionList = _permissionRepository.GetByProfileId(user.ProfileFK);

				//if (!securityInfo.PermissionList.Any(p => p.Module.ToUpper() == MOBILE))
				//{
				//	throw new Exception("El usuario no cuenta con los permisos necesarios");
				//}
			}
			else
			{
				throw new Exception("El correo o contraseña es incorrecta");
			}

			return securityInfo;
		}


		public async Task<string> GetToken(InputCredentialsViewModel credentials)
		{
			string token = string.Empty;
			User user = await _userRepository.GetByEmail(credentials.Email);

			string passwordHash = HashHelper.GetHash(user.PasswordHash, credentials.Password);
			if (user != null && user.PasswordHash  == passwordHash)
			{
				byte[] key = Encoding.ASCII.GetBytes(_jwtSetting.Secret);

				List<Claim> extraClaims = new List<Claim>
				{
					//new Claim( ClaimTypes.GroupSid, user.Office?.BusinessGroupFK != null ? user.Office?.BusinessGroupFK.ToString() : "" )
				};
				token = GenJwt(user.Id.ToString(), key, null, _jwtSetting.TimeLifeInDays);
			}

			return token;
		}

		private string GenJwt(string id, byte[] key, List<Claim> extraClaims = null, int timeLifeInDays = 7, DateTime issuedAt = default(DateTime))
		{
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			List<Claim> subjetClaims = new List<Claim> {
				new Claim(ClaimTypes.Sid, id),
				new Claim(ClaimTypes.System, "GSM" )
			};

			if (extraClaims != null && extraClaims.Count > 0)
				subjetClaims.AddRange(extraClaims);

			if (issuedAt == default(DateTime))
				issuedAt = DateTime.UtcNow;

			SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
			{
				Audience = "GMS",
				Expires = issuedAt.AddDays(timeLifeInDays),
				IssuedAt = issuedAt,
				Subject = new ClaimsIdentity(subjetClaims),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
			string tokenString = tokenHandler.WriteToken(token);
			return tokenString;
		}		
	}
}
