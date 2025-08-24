def so_cach(S, m, N):
    dp = [0] * (N + 1)
    dp[0] = 1

    for i in range(m):
        for j in range(S[i], N + 1):
            dp[j] += dp[ j - S[i] ]
    return dp[N]

N = int(input("Nhập vào số tiền cần đổi : "))
S = []
n = int(input("Nhập vào số lượng loại đồng xu mà bạn có : "))

for i in range(n):
    temp = int(input())
    S.append(temp)
m = len(S)    

print("Số cách để đổi", N, "xu là:", so_cach(S, m, N))
