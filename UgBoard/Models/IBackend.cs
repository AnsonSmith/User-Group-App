﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UgBoard.Models
{
    public interface IBackend
    {
        void Send(ICommand command);
        void Send<TResponse>(IQuery<TResponse> query, Action<TResponse> reply);
    }
}
