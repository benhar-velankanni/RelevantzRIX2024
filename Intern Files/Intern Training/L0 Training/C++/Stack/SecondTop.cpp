// Ex : 4	Create a C++ program for Finding the second top element from the Stack

#include <stdio.h>
#include <iostream>
#include <stack>

using namespace std;
main()
{
    stack<int> st;
    st.push(1);
    st.push(2);
    st.push(3);
    st.push(4);
    cout << "the elements in the stack are";
    int res = st.top() - 1;
    while (!st.empty())
    {
        cout << st.top() << " ";
        st.pop();
    }
    cout << "the top two element is ";
    cout << res;
}