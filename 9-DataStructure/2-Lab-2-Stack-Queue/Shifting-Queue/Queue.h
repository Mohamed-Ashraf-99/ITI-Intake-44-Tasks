//
// Created by Mohamed on 12/28/2023.
//

#ifndef QUEUE_SHIFTED_QUEUE_H
#define QUEUE_SHIFTED_QUEUE_H

template <class T>
class Queue {
    T *queue;
    int size;
    int front;
    int rear;
public:
    Queue(int _size);

    int enQueue(T _data);

    int deQueue(T &data);

    int peek(T &data);

    void print();

    int isFull();

    int isEmpty();
};

template<class T>
int Queue<T>::isEmpty() {return front == rear == -1;}

template<class T>
int Queue<T>::isFull() {return rear == size - 1;}

using namespace std;
template <class T>
Queue<T>::Queue(int _size){
    this->size = _size;
    this->front = -1;
    this->rear = -1;
    this->queue = new T[_size];
}

template<class T>
int Queue<T>::enQueue(T _data) {
    if(isFull())
        return 0;

    this->rear++;
    front = 0;
    this->queue[rear] = _data;
    return 1;
}

template<class T>
int Queue<T>::deQueue(T &data) {
    if(rear == -1)
        return 0;

    data = this->queue[front];
    for (int i = front; i < rear; i++) {
        if (front == rear) {
            front = rear = -1;
            break;
        }
        queue[i] = queue[i + 1];
    }
    rear--;
    return 1;
}

template<class T>
int Queue<T>::peek(T &data) {
    if(isEmpty())
        return 0;

    data = queue[front];
    return 1;
}

template<class T>
void Queue<T>::print() {
    cout <<"____________________________________________\n";
    for (int i = 0; i <= rear; i++) {
        cout << queue[i] << "\t";
    }
    cout << endl;
    cout <<"____________________________________________\n";

}




#endif //QUEUE_SHIFTED_QUEUE_H
