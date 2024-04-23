﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Label.Domain;
public interface IEntity<TPrimaryKey>
{
    TPrimaryKey Id { get; }
}
