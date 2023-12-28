#include <iostream>
#include "Stack.h"

using namespace std;
int main() {
    Stack<int> stack;
    stack.push(10);
    stack.push(20);
    stack.push(30);
    stack.push(40);
    stack.push(50);
    stack.push(60);
    stack.print();
    int num;
    if(stack.pop(num)) cout << "The number that was popped = " << num << "\n";
    else cout << "Faild\n";
    stack.print();
    if(stack.peek(num)) cout << "Top = " << num << "\n";
    else cout << "Faild\n";

    return 0;
}
