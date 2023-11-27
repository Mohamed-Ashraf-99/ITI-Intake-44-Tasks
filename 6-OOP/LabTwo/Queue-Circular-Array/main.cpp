#include <iostream>
using namespace std;

class Queue
{
   int *arr;
   int head;
   int rear;
   int length;
   int size;
public:
    Queue(int _size)
    {
        this->head = 0;
        this->rear = this->size - 1;
        this->length = 0;
    }
    bool isEmpty()
    {
        return this->length == 0;
    }
    bool isFull()
    {
        return this->length == this->size;
    }
    void enQueue(int item)
    {
        if(isFull())
            cout << "Queue Full" << endl;
        else
        {
            this->rear = (this->rear + 1 ) % (this->size);
            arr[this->rear] = item;
            this->length++;
        }
    }
    void deQueue()
    {
        if(isEmpty())
            cout << "Empty" << endl;
        else
        {
            this->head = (this->head + 1) % this->size;
            this->length--;

        }
    }
    int frontQueue()
    {
        if(isEmpty())
            return -1;
        return arr[this->head];
    }
    int rearQueue()
    {
        if(isEmpty())
            return -1;
        return arr[this->rear];
    }
    void printQueue()
    {
        for (size_t i = this->head; i != this->rear ; i = (i + 1) % this->size)
        {
             cout << arr[i] << endl;
        }
        cout << arr[this->rear] << endl;
    }
};
int main() {
    Queue q(10), q2(10);
    q.enQueue(10);
    q.enQueue(20);
    q.enQueue(30);
    q.enQueue(40);
    q.deQueue();
    q.deQueue();
    q.printQueue();
    cout << "===============" << endl;
    cout << q.frontQueue() << endl;
    cout << q.rearQueue()  << endl;

    return 0;
}
