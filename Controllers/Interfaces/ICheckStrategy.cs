using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoComunidades.Controllers.Interfaces
{
	public interface ICheckStrategy
	{
		bool Check(params string[] inputs);
	}

}
