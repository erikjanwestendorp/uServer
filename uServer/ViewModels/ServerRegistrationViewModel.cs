namespace uServer.ViewModels
{
    public class ServerRegistrationViewModel
    {
        public string ServerIdentity { get; set; }
        public string ServerAddress { get; set; }
        public bool IsSchedulingPublisher { get; set; }
        public bool IsActive { get; set; }
    }
}
