namespace MyCompanyName.AbpZeroTemplate.Authorization.Users.Profile.Dto
{
    public class GetProfilePictureOutput
    {
        public GetProfilePictureOutput(string profilePicture)
        {
            ProfilePicture = profilePicture;
        }

        public string ProfilePicture { get; set; }
    }
}