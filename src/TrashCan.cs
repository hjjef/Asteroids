using System;
using System.Collections.Generic;


namespace MyGame
{
    public class TrashCan
    {
		List<GameObject> _toDelete;

        public TrashCan ()
        {
			_toDelete = new List<GameObject>();
        }

		public void Add(GameObject obj)
		{
			_toDelete.Add(obj);
		}

		public void DeleteTick()
		{
			_toDelete.Clear();
		}
    }
}
