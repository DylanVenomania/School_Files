import pygame

pygame.init()

screen = pygame.display.set_mode((800, 600))
pygame.display.set_caption("Giới hạn ranh giới trong Pygame")


obj_width, obj_height = 50, 50
x, y = 4400, 300 
speed = 0.5

running = True
while running:
    screen.fill("white")  

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


    x = max(0, min(800- obj_width, x))
    y = max(0, min(600 - obj_height, y))


    pygame.draw.rect(screen, "black", (x, y, obj_width, obj_height))

    pygame.display.flip()

pygame.quit()