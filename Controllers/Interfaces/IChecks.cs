﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Modelo;

namespace ProyectoComunidades.Controllers.Interfaces
{
	public interface IChecks
	{
		bool ValidateInput(params string[] inputs);
	}

}
