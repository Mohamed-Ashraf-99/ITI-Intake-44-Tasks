//
// Created by Mohamed on 11/28/2023.
//

#ifndef STACK_OVER_LOADING_STACK_H
#define STACK_OVER_LOADING_STACK_H

template<class T>
class Stack {
    T *data;
    int top;
    int initial_size;
    int current_size;
    static int objCount;
public:
    Stack();
    Stack(int size);
    Stack(Stack &S);
    ~Stack();
    void resize();

    void push(T item);

    int  peek();

    int pop();

    bool isEmpty();

    int size();

    void print() const;

    Stack reverse();

    int getObjCount();

    const Stack operator=(const Stack &right);
    const Stack operator+(const Stack &right);
};


#endif //STACK_OVER_LOADING_STACK_H
