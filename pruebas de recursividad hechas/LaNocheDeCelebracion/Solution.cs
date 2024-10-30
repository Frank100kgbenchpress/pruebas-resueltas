using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

namespace LaNocheDeCelebracion;

public class Solution
{
  //elimina movimientos duplicados
  public static List<(int , int)> LimpiarLista(  List<(int , int)> movimientosPosibles)
  {     
    List<(int , int)> list =  new();
    foreach((int , int) e in  movimientosPosibles)
    {
      if(!list.Contains(e))    list.Add(e);            
    }
    return list ; 
  }

    public static List<(int , int)> MovimientosPosibles((int fila , int columna) posActual ,bool[,] map)
    {       
      int fila = posActual.fila;
      int columna = posActual.columna;
      (int fila , int columna) posAuxiliar ; 
      posAuxiliar.fila = fila;
      posAuxiliar.columna = columna;
      List<(int , int)> movimientosPosibles = new();
        // Movimientos Arriba 
      for (int  i = 0; i < 3; i++)
      {    
        posAuxiliar.fila = (posAuxiliar.fila == 0) ? map.GetLength(0) - 1 : posAuxiliar.fila - 1;
      }
      if( posAuxiliar.columna == 0 )
      {
        posAuxiliar.columna = map.GetLength(1) - 1 ; 
        if(!map[posAuxiliar.fila,posAuxiliar.columna])  movimientosPosibles.Add(posAuxiliar);   
      }
      else
      {
        posAuxiliar.columna --;
        if(!map[posAuxiliar.fila,posAuxiliar.columna])
        {
          movimientosPosibles.Add(posAuxiliar);
        }
      }
      posAuxiliar.columna = columna;
      if( posAuxiliar.columna == map.GetLength(1) - 1 )
      {
        posAuxiliar.columna = 0; 
        if(!map[posAuxiliar.fila,posAuxiliar.columna])  movimientosPosibles.Add(posAuxiliar);   
      }
      else
      {
        posAuxiliar.columna ++;
        if(!map[posAuxiliar.fila,posAuxiliar.columna])  movimientosPosibles.Add(posAuxiliar);
      }
      posAuxiliar.fila = fila;
      posAuxiliar.columna = columna;
    // Movimientos Abajo 
      for (int  i = 0; i < 3; i++)
      {    
        posAuxiliar.fila = (posAuxiliar.fila < map.GetLength(0) - 1) ? posAuxiliar.fila + 1 : 0;
      }
      if( posAuxiliar.columna == 0 )
      {
        posAuxiliar.columna = map.GetLength(1) - 1 ; 
        if(!map[posAuxiliar.fila,posAuxiliar.columna])    movimientosPosibles.Add(posAuxiliar);     
      }
      else
      {
        posAuxiliar.columna --;
        if(!map[posAuxiliar.fila,posAuxiliar.columna])
        {
          movimientosPosibles.Add(posAuxiliar);
        }
      }
      posAuxiliar.columna = columna;
      if( posAuxiliar.columna == map.GetLength(1) - 1 )
      {
        posAuxiliar.columna = 0; 
        if(!map[posAuxiliar.fila,posAuxiliar.columna])  movimientosPosibles.Add(posAuxiliar);   
      }
      else
      {
        posAuxiliar.columna ++;
        if(!map[posAuxiliar.fila,posAuxiliar.columna])
        {
          movimientosPosibles.Add(posAuxiliar);
        }
      }
      posAuxiliar.fila = fila;
      posAuxiliar.columna = columna;
      // Movimientos Derecha 
      for (int  i = 0; i < 3; i++)
      {    
        posAuxiliar.columna = (posAuxiliar.columna < map.GetLength(1) - 1) ? posAuxiliar.columna + 1 : 0;
      }
      if( posAuxiliar.fila == 0 )
      {
        posAuxiliar.fila = map.GetLength(0) - 1 ; 
        if(!map[posAuxiliar.fila,posAuxiliar.columna])    movimientosPosibles.Add(posAuxiliar);   
      }
      else
      {
        posAuxiliar.fila --;
        if(!map[posAuxiliar.fila,posAuxiliar.columna])  movimientosPosibles.Add(posAuxiliar);
      }
      posAuxiliar.fila = fila;
      if( posAuxiliar.fila == map.GetLength(0) - 1 )
      {
        posAuxiliar.fila = 0; 
        if(!(map[posAuxiliar.fila,posAuxiliar.columna]))
        {
          movimientosPosibles.Add(posAuxiliar);   
        }
      }
      else
      {
        posAuxiliar.fila ++;
        if(!map[posAuxiliar.fila,posAuxiliar.columna]) movimientosPosibles.Add(posAuxiliar);
      }
      posAuxiliar.fila = fila;
      posAuxiliar.columna = columna;
       // Movimientos Izquierda
      for (int  i = 0; i < 3; i++)
      {    
        posAuxiliar.columna = (posAuxiliar.columna > 0) ? posAuxiliar.columna - 1 : map.GetLength(1) - 1;
      }
      if( posAuxiliar.fila == 0 )
      {
        posAuxiliar.fila = map.GetLength(0) - 1 ; 
        if(!map[posAuxiliar.fila,posAuxiliar.columna])    movimientosPosibles.Add(posAuxiliar);   
      }
      else
      {
        posAuxiliar.fila --;
        if(!map[posAuxiliar.fila,posAuxiliar.columna])    movimientosPosibles.Add(posAuxiliar);
      }
      posAuxiliar.fila = fila;
      if( posAuxiliar.fila == map.GetLength(0) - 1 )
      {
        posAuxiliar.fila = 0; 
        if(!map[posAuxiliar.fila,posAuxiliar.columna])    movimientosPosibles.Add(posAuxiliar);   
      }
      else
      {
        posAuxiliar.fila ++;
        if(!map[posAuxiliar.fila,posAuxiliar.columna])  movimientosPosibles.Add(posAuxiliar);
      }
      posAuxiliar.fila = fila;
      posAuxiliar.columna = columna;
      return movimientosPosibles;
    }
    public static int MinStepHome(bool[,] map, (int, int) home)
    {   
      int minimo = -1 ; 
      HashSet<(int, int)> CaminosRecorridos = new();
      Mover (home , (0,0) , 0);
      void Mover( (int, int) home , (int, int) posActual  , int MinimoActual)
      {
        if(CaminosRecorridos.Contains(posActual))  return;
        List<(int , int)> movimientosPosibles =  LimpiarLista( MovimientosPosibles( posActual ,map));
        if(posActual == home)
        {  
          minimo = minimo == -1 ? MinimoActual : Math.Min(minimo, MinimoActual);                
          return ;   
        }
        if(movimientosPosibles.Count == 0 )  return;
        if(MinimoActual >= minimo && minimo != -1 ) return ; 
        foreach( (int, int) pos in movimientosPosibles)
        {   
          CaminosRecorridos.Add(posActual);
          Mover( home , pos ,  MinimoActual + 1 ) ;
          CaminosRecorridos.Remove(posActual);   
        }
      }
      return  minimo; 
    }
}

