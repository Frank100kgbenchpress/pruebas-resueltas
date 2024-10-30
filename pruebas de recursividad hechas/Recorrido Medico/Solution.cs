namespace Recorrido
{
    class Solution
    {
        public static int CantidadMinimaDeMedicos(int[,] area, int radio)
        {
            (List<Medico> medicos ,  int pacientes)  = Find(area);
            int best = int.MaxValue;
            Backtrack(0,medicos.Count);
            return best == int.MaxValue? -1 : best;
            void Backtrack(int start,int used)
            {
                if(used == 0) return;
                if(start == medicos.Count)
                {
                    if(CheckArea(area,radio,medicos,pacientes))
                    {
                        best = Math.Min(best,used);
                    }
                    return;
                }
                Medico temp = medicos[start];
                medicos[start] = null ; 
                Backtrack(start + 1 , used - 1);
                medicos[start] = temp ; 
                Backtrack(start + 1 , used);
            }
        }
        static bool CheckArea(int[,] area, int radio, List<Medico> medicos, int countPacientes)
        {
            int count = 0;
            bool[,] mask = new bool[area.GetLength(0),area.GetLength(1)];
            foreach (var medico in medicos)
            {   if(medico is not null)
                {
                    for (int i = Math.Max(0, medico.Fila-radio); i <= Math.Min(medico.Fila+radio, area.GetLength(0)-1); i++)
                    {
                        for (int j = Math.Max(0, medico.Columna-radio); j <= Math.Min(medico.Columna+radio, area.GetLength(1)-1); j++)
                        {
                            if (area[i,j] == 2 && !mask[i,j])
                            {
                                count++;
                                mask[i, j] = true;
                            }
                        }
                    }
                }
                
            }

            return count == countPacientes;
        }
        static (List<Medico>,int) Find(int[,] area)
        {   
            int pacientes = 0 ; 
            List<Medico> doctors = new() ; 
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {   
                    if(area[i,j] == 1)    doctors.Add(new Medico(i,j));
                    else if(area[i,j] == 2)    pacientes ++ ; 
                }
            }
            return (doctors,pacientes) ; 
        }
    }
    class Medico 
    {
        public int Fila {get;}  
        public int Columna {get;}  
        public Medico(int fila , int columna) => (Fila,Columna) = (fila,columna);
    }
}

