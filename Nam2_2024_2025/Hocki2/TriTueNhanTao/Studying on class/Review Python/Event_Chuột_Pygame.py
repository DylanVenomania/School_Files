import pygame

pygame.init()
screen = pygame.display.set_mode ( (600, 600), pygame.RESIZABLE)


running = True
while running:

    for event in pygame.event.get():
        if event.type == pygame.MOUSEMOTION: 
            if event.rel[ 0 ] > 0:
                print( "Di chuyển sang phải")

            elif event.rel[ 1 ] > 0:
                print( "Di chuyển xuống dưới")
        elif event.type == pygame.MOUSEBUTTONDOWN:
            if event.button == 1:
                pos = event.pos
                print("Nhấn chuột trái")
                pygame.draw.rect( screen, ('white'), [pos[0], pos[1], 50,50], 1)
                pygame.display.update()

            if event.button == 2:
                print("Nhấn chuột giữa")

            if event.button == 3:
                print("Nhấn chuột phải")
        elif event.type == pygame.MOUSEBUTTONUP : 
            print("Nút chuột được thả ra")



        if event.type == pygame.QUIT:
            running = False

pygame.display.quit()