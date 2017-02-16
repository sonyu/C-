#include <stdio.h>

#include<iostream>
using namespace std;
int main()
{
	int dem =5;
	int so =1;
	for(int i =1; i<=9; i++)
	{
		for(int j=1;j<=9;j++)
		{
			
			if(j==dem)
			{
				for(int z =1; z<=so;z++)
				{
					cout<<"*";
				}
				
			}
			cout<<" ";
		}
		dem--;
		so=so+2;
		cout<<"\n";
	}
	cout<<"\n";
	dem =5;
	so =1;
	for(int i =1; i<=9; i++)
	{
		for(int j=1;j<=9;j++)
		{
			
			if(j==dem)
			{
				for(int z =1; z<=so;z++)
				{
					cout<<"*";
				}
				
			}
			cout<<" ";
		}
		dem--;
		so++;
		cout<<"\n";
	}

	cout<<"\n";
	dem =5;
	so =1;
	for(int i =1; i<=5; i++)
	{
		for(int j=1;j<=9;j++)
		{
			
			if(j==dem)
			{
				for(int z =1; z<=so;z++)
				{
					cout<<"*";
				}
				
			}
			//cout<<" ";
		}
		//dem++;
		so++;
		cout<<"\n";
	}
	getchar();	
	return 0;
}