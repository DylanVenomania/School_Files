số = int(input())
print('Bảng cửu chương của ', số, ' : ')
for i in range(1,11):
    print(số, 'x {0} ='.format(i), '{0}'.format(số*i) )
