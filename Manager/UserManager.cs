using BootCamp.Adm.Commons;
using BootCamp.Adm.Entities;
using BootCamp.Adm.Filters;
using BootCamp.Adm.Helpers;
using BootCamp.Adm.Manager.Interfaces;
using BootCamp.Adm.Security;
using BootCamp.Adm.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCamp.Adm.IRepository;
using BootCamp.Adm.Settings;
using Microsoft.Extensions.Options;

namespace BootCamp.Adm.Manager
{

    [AuthorizationFilter]
	public class UserManager : BaseManager<User, InputUserViewModel, OutputUserViewModel>, IUserManager
    {
        readonly ApiConfigSettings _apiConfigSettings;
		readonly IUserRepository _userRepository;
		const bool Active = true;

		public UserManager(
            IOptions<ApiConfigSettings> apiConfigSettingsOpt
			, IUserRepository repository
            ) : base(repository)
        {
            _apiConfigSettings = apiConfigSettingsOpt.Value;
			_userRepository = repository;
		}

		public Tuple<List<OutputUserViewModel>, PagedResult<OutputUserViewModel>> GetUsers(QueryParameter pagingParameter, UserFilter filter)
		{
            PagedResult<User> source = _userRepository.Get().GetPaged(pagingParameter, filter);
			List<User> resources = source.Results.ToList();

			List<OutputUserViewModel> resourceViewModel =  this.PrepareMultipleReturn(resources);
            PagedResult<OutputUserViewModel> sourceViewModel = new PagedResult<OutputUserViewModel>()
            {
                CurrentPage = source.CurrentPage,
                NextPage = source.NextPage,
                PageCount = source.PageCount,
                PageSize = source.PageSize,
                PreviousPage = source.PreviousPage,
                Results = resourceViewModel,
                Total = source.Total,
                TotalPages = source.TotalPages
            };
			source.Results = null;
			return new Tuple<List<OutputUserViewModel>, PagedResult<OutputUserViewModel>>(resourceViewModel, sourceViewModel);
		}

		[AllowAnonymous]
		public override async Task<OutputUserViewModel> Post(InputUserViewModel model)
		{
			User user = await _userRepository.GetByEmail(model.BusinessEmail);
			if (user != null)
			{
				throw new Exception("Correo ya registrado");
			}
			var entity = PrepareAddData(model);
			user = await _userRepository.Post(entity);

			return PrepareSingleReturn(user);
		}

		public override async Task Patch(int id, InputUserViewModel model)
		{
			//if (await _userRepository.ValidateEmailToUpdate(id, model.BusinessEmail))
			//{
			//	throw new Exception("Correo ya registrado");
			//}

			var entity = await _userRepository.GetById(id);

			var updatedEntity = PrepareUpdateData(entity, model);

			await _userRepository.Patch(updatedEntity);
		}

		public async Task PatchPassword(int id, string password)
		{
			User entity = await _userRepository.GetById(id);

			string passwordHash = HashHelper.GetHash(_apiConfigSettings.SecuritySalt, password);

			entity.UpdatedAt = DateTime.Now;
			await _userRepository.Patch(entity);
		}

		public override User PrepareAddData(InputUserViewModel viewModel)
		{
			string passwordHash = HashHelper.GetHash(_apiConfigSettings.SecuritySalt, viewModel.Password);

			return new User()
			{
				Name = viewModel.Name,
                
				PasswordHash = passwordHash,
                CreatedAt = DateTime.Now
			};
		}

		public override User PrepareUpdateData(User entity, InputUserViewModel viewModel)
		{
			entity.Name = viewModel.Name;

			entity.UpdatedAt = DateTime.Now;

			return entity;
		}

		public override OutputUserViewModel PrepareSingleReturn(User entity)
		{
			return new OutputUserViewModel()
			{
				Id = entity.Id,
				Name = entity.Name,
				CreatedAt = entity.CreatedAt,
				UpdatedAt = entity.UpdatedAt
			};
		}

		public override List<OutputUserViewModel> PrepareMultipleReturn(IEnumerable<User> entities)
		{
			return entities.Select(p => new OutputUserViewModel()
			{
				Id = p.Id,
				Name = p.Name,
				CreatedAt = p.CreatedAt,
				UpdatedAt = p.UpdatedAt
			}).ToList();
		}

		public async Task<bool> GeneratePassword(string email)
		{
			var entity = await _userRepository.GetByEmail(email);		

			if (entity == null)
			{
				throw new Exception("El correo no es válido");
			}

			var password = GeneratePassword();
			await PatchPassword(entity.Id, password);

			Email.SendMail(entity.Email, "Nueva contraseña", "Su nueva contraseña es:" + password);
			return Active;
		}

		public string GeneratePassword()
		{
			Random random = new Random();
			string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			StringBuilder result = new StringBuilder(10);
			for (int i = 0; i < 10; i++)
			{
				result.Append(characters[random.Next(characters.Length)]);
			}
			return result.ToString();
		}

        public async Task<List<User>> GetAll()
        {
			return await _userRepository.GetAll();
        }

		public async Task<User> GetBymail(string mail)
		{
			return await _userRepository.GetByEmail(mail);
		}
	}
}


