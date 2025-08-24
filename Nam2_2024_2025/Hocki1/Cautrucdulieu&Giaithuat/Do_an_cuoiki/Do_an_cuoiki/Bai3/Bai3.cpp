#include <iostream>
#include <stack>
#include <string>
#include <vector>
#include <sstream>
#include <cctype>
using namespace std;

class calculator {
public:
    double evaluate(const string& expression) {
        vector<string> postfix = infixToPostfix(expression);
        return countPostfix(postfix);
    }

private:
    int precedence(char op) {
        if (op == '+' || op == '-') return 1;
        if (op == '*' || op == '/') return 2;
        return 0;
    }

    double count(double a, double b, char op) {
        switch (op) {
        case '+': return a + b;
        case '-': return a - b;
        case '*': return a * b;
        case '/':
            if (b == 0) {
                throw runtime_error("Khong the chia cho 0.");
            }
            return a / b;
        default:
            throw runtime_error("Toan tu khong hop le.");

        }
    }

    vector<string> infixToPostfix(const string& exp) {
        vector<string> output;
        stack<char> operators;
        string token;

        for (size_t i = 0; i < exp.length(); i++) {
            char current = exp[i];
            if (isdigit(current)) {
                token.clear();
                while (i < exp.length() && isdigit(exp[i])) {
                    token += exp[i];
                    i++;
                }
                output.push_back(token);
                i--;
            }
            else if (current == '(') {
                operators.push('(');
            }
            else if (current == ')') {
                while (!operators.empty() && operators.top() != '(') {
                    output.push_back(string(1, operators.top()));
                    operators.pop();
                }
                if (operators.empty()) {
                    throw runtime_error("Thieu dau ngoac.");
                }
                operators.pop();
            }
            else {
                while (!operators.empty() && precedence(operators.top()) >= precedence(current)) {
                    if (operators.top() == '(') {
                        throw runtime_error("Thieu dau ngoac.");
                    }
                    output.push_back(string(1, operators.top()));
                    operators.pop();
                }
                operators.push(current);
            }
        }

        while (!operators.empty()) {
            if (operators.top() == '(') {
                throw runtime_error("Thieu dau ngoac.");
            }
            output.push_back(string(1, operators.top()));
            operators.pop();
        }
        return output;
    }

    double countPostfix(const vector<string>& postfix) {
        stack<double> values;

        for (const string& token : postfix) {
            if (isdigit(token[0]) || (token.size() > 1 && token[0] == '-')) {
                try {
                    values.push(stod(token));
                }
                catch (const invalid_argument&) {
                    throw runtime_error("Khong the chuyen doi thanh so.");
                }
            }
            else {
                if (values.size() < 2) {
                    throw runtime_error("Bieu thuc khong hop le.");
                }
                double b = values.top(); values.pop();
                double a = values.top(); values.pop();
                values.push(count(a, b, token[0]));
            }
        }

        if (values.size() != 1) {
            throw runtime_error("Bieu thuc khong hop le");
        }
        return values.top();
    }
};

int main() {
    string expression;
    cout << "Nhap bieu thuc: ";
    getline(cin, expression);

    calculator cal;
    try {
        double result = cal.evaluate(expression);
        cout << "Gia tri bieu thuc: " << result << endl;
    }
    catch (const runtime_error& e) {
        cout << e.what() << endl;
    }
    return 0;
}