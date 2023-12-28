#include <iostream>
#include "Queue.h"

using namespace std;
int main() {
    Queue<int> queue(10);

    queue.enQueue(10);
    queue.enQueue(20);
    queue.enQueue(30);
    queue.enQueue(40);
    queue.enQueue(50);
    queue.enQueue(60);
    queue.print();
    int num;
    while (queue.deQueue(num)){
        cout << "The deleted item:  " << num << endl;
        queue.print();
        cout << endl;

    }
    return 0;
}
