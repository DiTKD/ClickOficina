using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickOficina.Data
{
    public interface ClickOficinaDB
    {
        SQLiteConnection GetConexao();
    }
}
