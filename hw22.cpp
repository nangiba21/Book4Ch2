#include <ostream>
#include <cstdlib>
#include <string>
#include <iostream>
using namespace std;
const int size = 10;

void generateRand(int array[], int size)
{
    for (int i = 0; i < size; i++)
    {
        array[i] = ((std::rand() % 50) * 2) + 1;
    }
}
void printTheArray(const int arr[], int size, const string& arrayName, ostream& out)
{
    out << "Array:" << arrayName << "";
    for (int i = 0; i < size; i++)
    {
        out << arr[i] << "";
    }
}