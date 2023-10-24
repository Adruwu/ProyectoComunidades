using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoComunidades.Controllers.Interfaces
{
	public interface IGenericList<T>
	{
		public void AddToList(T elemento);
		public void ShowList();
		public List<T> GetList();

	}
}
