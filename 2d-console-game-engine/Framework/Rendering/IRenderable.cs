using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public interface IRenderable
    {
        int GetSortOrder { get; }
        object OnRender();
        Bounds GetBounds();
    }
}
