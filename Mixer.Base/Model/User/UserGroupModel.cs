﻿namespace Mixer.Base.Model.User
{
    public class UserGroupModel : TimeStampedModel
    {
        public uint id { get; set; }
        public string type { get; set; }
    }
}
