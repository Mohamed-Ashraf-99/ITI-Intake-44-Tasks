#include <iostream>
#include "Queue.h"

using namespace std;
int main() {
    Queue<int> queue;
    queue.enQueue(10);
    queue.enQueue(20);
    queue.enQueue(30);
    queue.enQueue(40);
    queue.enQueue(50);
    queue.print();
    int num;
    if(queue.deQueue(num)) cout << "The number that was deleted = " << num << "\n";
    else cout << "Faild\n";
    queue.print();
    if(queue.peek(num)) cout << "First = " << num << "\n";
    return 0;
}
