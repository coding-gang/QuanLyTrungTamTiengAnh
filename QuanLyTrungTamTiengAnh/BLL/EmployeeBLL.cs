﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IConfiguration;
using Core.UnitOfWork;
namespace BLL
{
    public class EmployeeBLL
    {
        public IUnitOfWork _unitOfWork { get; private set; }
        public EmployeeBLL(IUnitOfWork unitOfWork) 
        {
            this._unitOfWork = unitOfWork;
        } 
    

    }
}
