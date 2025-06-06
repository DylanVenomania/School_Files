import pygame

pygame.init()
screen = pygame.display.set_mode( (600, 400) )
clock = pygame.time.Clock( )


x, y = 250, 300
gravity = 1
velocity = 0
jump_power = -15
is_jumping = False

running = True
while running:
    screen.fill("white")

    for event in pygame.event.get( ):
        if event.type == pygame.QUIT:
            running = False
        elif event.type == pygame.KEYDOWN:
            if event.key == pygame.K_SPACE and not is_jumping:
                velocity = jump_power  
                is_jumping = True

    velocity += gravity
    y += velocity

    if y >= 300: 
        y = 300
        is_jumping = False

    pygame.draw.rect(screen, "black", (x, y, 50, 50))

    pygame.display.flip()
    clock.tick(30)

pygame.quit()