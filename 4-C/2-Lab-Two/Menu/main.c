#include <stdio.h>
#include <stdlib.h>

int main()
{
    printf("Welcom! \n");
    printf("Choose what do you want to eat from the following \n"
           "1-Pizza \n"
           "2-Soup \n"
           "3-dessert \n");
    int c;
    scanf("%d", &c);
    switch(c)
    {
    case 1:
        printf("You chosen Pizza \n");
        break;
    case 2:
        printf("You chosen soup \n");
        break;
    case 3:
        printf("You chosen dessert \n");
        break;
    default:
        do
        {
            printf("Sorry we don't have this in our Menu choose another number\n");
            scanf("%d", &c);
        }while(c != 1 && c != 2 && c != 3);
        break;
    }
    return 0;
}
