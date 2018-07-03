using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    [Serializable()]
    public static class Metodos
    {
        public static List<Usuario> usuarios = new List<Usuario>();

        public static void Serializar()
        {
            FileStream fs = new FileStream("usuario.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, usuarios);
            }
            catch (SerializationException e)
            {

            }
            finally
            {
                fs.Close();
            }
        }


        public static void Deserializar()
        {
            List<Usuario> usuarios1 = new List<Usuario>();
            FileStream fs = new FileStream("usuario.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                usuarios1 = (List<Usuario>)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
            }
            finally
            {
                fs.Close();
            }

            foreach (Usuario u in usuarios1)
            {
                usuarios.Add(u);
            }
        }
    }
}
