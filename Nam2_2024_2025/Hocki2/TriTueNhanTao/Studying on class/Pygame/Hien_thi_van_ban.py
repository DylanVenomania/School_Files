import pygame

pygame.init()

screen = pygame.display.set_mode( (600, 600), pygame.RESIZABLE )


txt_font = pygame.font.Font(None, 36)

txt_surface = txt_font.render("May the peace be with us!", True, (255,255,255) )

screen.blit( txt_surface, (150, 300) )

pygame.display.flip()

running = True
while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
pygame.quit