#include <iostream>
using namespace std;

template <class T>

class Stack
{
    T *data;
    int top;
    int initial_size;
    int current_size;
public:
    Stack() : initial_size(5), current_size(this->initial_size), top(-1), data(new int [this->initial_size])
    {}
    ~Stack()
    {delete []this->data;}
    void resize()
    {
        if(this->top < this->current_size - 1) return;

        int newSize = this->current_size * 1.5;
        T *newArr = new int [newSize];
        std:copy(this->data, this->data + this->current_size, newArr);
        this->current_size *= 1.5;

        delete[] this->data;
        this->data = newArr;
    }
    void push(int item)
    {
        this->resize();
        this->data[++this->top] = item;
    }
    int  peek()
    {
        if (this->top == -1)  return 0;
        return this->data[this->top];
    }
    int pop()
    {
        if (this->top == -1)  return 0;
        int head_data = this->data[this->top];
        this->data[this->top] = 0;
        this->top--;
        return head_data;
    }
    bool isEmpty()
    {
        if (this->top == -1) return true;
        else return false;
    }
    int size()
    {
        return this->top + 1;
    }
    void print()
    {
        for (int i = this->top  ; i >= 0 ; i--) {
            cout << this->data[i] << endl;
        }
        cout << "\n";
    }
};
int main() {
    Stack<int> s;
    s.push(10);
    s.push(20);
    s.push(30);
    s.push(40);
    s.push(50);
    s.print();
    cout << "===========================" << endl;
    s.pop();
    s.pop();
    s.print();
    cout << "====================================" << endl;
    cout << s.peek() << endl;
    cout << "====================================" << endl;
    cout << s.size() << endl;
    return 0;
}
