namespace UserAccount.UserAccount.Services;

public interface IUserAccountService
{
   /// <summary>
   /// Create user account
   /// </summary>
   /// <param name="email"></param>
   /// <param name="password"></param>
   /// <returns></returns>
   Task<UserAccountModel> Create(RegisterUserAccountModel model);
  
}