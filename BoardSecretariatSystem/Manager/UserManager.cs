﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardSecretariatSystem.DAO;
using BoardSecretariatSystem.Gateway;

namespace BoardSecretariatSystem.Manager
{
  public  class UserManager
    {
        public UserGateway aGateway;

        public int SaveUser(User aUser)
        {
            aGateway = new UserGateway();
            return aGateway.SaveUser(aUser);
        }
    }
}
