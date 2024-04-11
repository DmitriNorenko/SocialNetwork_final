using SocialNetwork_final.DB.Model;
using SocialNetwork_final.ViewModels.Account;

namespace SocialNetwork_final.Models
{
    public static class UserFromModel
    {
        public static User Convert(this User user,UserEditViewModel userEdit)
        {
            user.Image = userEdit.Image;
            user.LastName = userEdit.LastName;
            user.MiddleName = userEdit.MiddleName;
            user.FirstName = userEdit.FirstName;
            user.Email = userEdit.Email;
            user.BirthDate = userEdit.BirthDate;
            user.UserName = userEdit.Email;
            user.Status = userEdit.Status;
            user.About = userEdit.About;

            return user;
        }
    }
}
