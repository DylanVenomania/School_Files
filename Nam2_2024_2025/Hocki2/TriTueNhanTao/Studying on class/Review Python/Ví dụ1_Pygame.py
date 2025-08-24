import pygame

screen = pygame.display. set_mode ( (600,600), pygame.RESIZABLE )

pygame.draw.rect( screen, ('white') , [200, 200, 200, 200] )
pygame.draw.circle( screen, ('blue'), [ 300, 300 ], 50 )
pygame.display.flip()

running = True
while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

pygame.display.quit()
