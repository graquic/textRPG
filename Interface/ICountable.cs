﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public interface ICountable
    {
        public int GetItemCount();

        public void AddItemCount();

        public void DecreaseItemCount();
    }
}
