﻿namespace Domain.Models
{
    public class Skill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<UserInfo> UserInfos { get; set; }

    }
}
