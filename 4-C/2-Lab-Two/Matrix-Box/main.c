#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>


void gotoxy( int column, int line )
  {
  COORD coord;
  coord.X = column;
  coord.Y = line;
  SetConsoleCursorPosition(
    GetStdHandle( STD_OUTPUT_HANDLE ),
    coord
    );
  }


int main()
{
    int size;
    do
    {
        printf("Enter your number: \n");
        scanf("%d",&size);
    }while(size < 3 || size % 2 == 0);

    int row=1,col = (size + 1)/2;
    for(int i = 1 ; i<= size*size ; i++)
    {
        gotoxy(col*6,row*3);
        printf("%d",i);
        if(i%size)
        {
            row--;
            col--;
            if(row == 0)
            {
                row = size;
            }

            if(col == 0)
            {
                col = size;
            }
        }
        else
        {
            row++;
            if(row > size)
            {
                row = 1;
            }
        }
    }
    return 0;
}
