﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Service;

namespace NTK.EventsArgs
{
    /// <summary>
    /// réception du service
    /// </summary>
    public class GetServiceEventArgs : EventArgs
    {
        private NTKService service;


        public GetServiceEventArgs(NTKService service)
        {
            this.service = service;
        }
        public NTKService get
        {
            get { return service; }
        }


    }
}
