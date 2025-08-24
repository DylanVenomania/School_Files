import pygame

pygame.init()
screen = pygame.display.set_mode((600, 400))
pygame.display.set_caption("Vẽ bằng phím mũi tên")


x, y = 300, 200  
path = [(x, y) ]  

running = True
while running:
    screen.fill( (255, 255, 255))

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        elif event.type == pygame.KEYDOWN:
            if event.key == pygame.K_UP:
                y -= 10
            elif event.key == pygame.K_DOWN:
                y += 10
            elif event.key == pygame.K_LEFT:
                x -= 10
            elif event.key == pygame.K_RIGHT:
                x += 10
            path.append((x, y))  

    
    if len(path) > 1:
        pygame.draw.lines(screen, (0,0,0 ) , False, path, 3)

    pygame.display.flip()

pygame.quit()