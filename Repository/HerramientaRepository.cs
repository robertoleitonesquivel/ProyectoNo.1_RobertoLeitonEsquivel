﻿using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HerramientaRepository : CrudRepository<Herramienta>, IHerramientaRepository
    {
    }
}