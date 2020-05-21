using System;

namespace MyPersonalDiary.com.Domain.Services
{
    [Serializable]
    public class SessionState
    {
        public static SessionState GetSession()
        {
            // TODO: Restore from session
            return new SessionState
            {
                User = new UserVo
                {
                    Id = Guid.Parse("EF3477BD-E415-407F-91A9-66FA8E9E632B"),
                    Name = "Shahid Ali",
                    Email = "shahid.ali@mypersonaldiary.com",
                    UserName = "sha"
                }
            };
        }

        public UserVo User { get; set; }
    }
}
