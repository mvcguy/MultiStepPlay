using System;

namespace MyPersonalDiary.com.Domain.Services
{
    [Serializable]
    public class UserVo
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
