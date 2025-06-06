import pygame

pygame.init()
screen = pygame.display.set_mode((600, 400))
pygame.display.set_caption("Di chuyển đối tượng")


x, y = 250, 150  
speed = 0.1

running = True
while running:
    screen.fill(( 255,255,255))  

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

    keys = pygame.key.get_pressed()
    if keys[pygame.K_UP]:
        y -= speed
    if keys[pygame.K_DOWN]:
        y += speed
    if keys[pygame.K_LEFT]:
        x -= speed
    if keys[pygame.K_RIGHT]:
        x += speed

    pygame.draw.rect(screen, "black", (x, y, 50, 50))  

    pygame.display.flip()

pygame.quit()