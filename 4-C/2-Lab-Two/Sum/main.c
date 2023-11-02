#include <stdio.h>
#include <stdlib.h>

int main()
{
    int sum = 0;
    while(sum <= 100)
    {
       printf("Enter you number: \n");
       int x;
       scanf("%d",&x);
       sum += x;
    }
    printf("%d",sum);
    return 0;
}
