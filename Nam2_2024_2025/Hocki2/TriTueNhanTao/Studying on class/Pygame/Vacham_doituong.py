import pygame

pygame.init()

rong, cao = 800, 600
screen = pygame.display.set_mode((rong, cao))
pygame.display.set_caption("Phát hiện va chạm ")


player = pygame.Rect(100, 100, 50, 50)
enemy = pygame.Rect(400, 300, 50, 50)

player_x, player_y = float(player.x), float(player.y)
speed = 5

clock = pygame.time.Clock() 

running = True
while running:
    dt = clock.tick(60) / 1000 
    screen.fill("white")

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

    keys = pygame.key.get_pressed()
    if keys[pygame.K_UP]:
        player_y -= speed * dt * 100
    if keys[pygame.K_DOWN]:
        player_y += speed * dt * 100
    if keys[pygame.K_LEFT]:
        player_x -= speed * dt * 100
    if keys[pygame.K_RIGHT]:
        player_x += speed * dt * 100


    player.x, player.y = round(player_x), round(player_y)

    if player.colliderect(enemy):
        print("Va chạm!")


    pygame.draw.rect(screen, 'red', player)
    pygame.draw.rect(screen, "black", enemy)

    pygame.display.flip()

pygame.quit()
