import pygame

pygame.init()
screen = pygame.display.set_mode((600, 400))
pygame.display.set_caption("Tạo nút trong Pygame")


font = pygame.font.Font(None, 40)
text = font.render("Press me !", True, (0,0,0) )
button_rect = pygame.Rect(200, 150, 200, 80)

running = True
while running:
    screen.fill((30, 30, 30))  
    pygame.draw.rect(screen, (255,255,255), button_rect) 
    screen.blit(text, (button_rect.x + 35, button_rect.y + 25)) 

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        elif event.type == pygame.MOUSEBUTTONDOWN:
            if button_rect.collidepoint(event.pos ):  
                print("Nút đã được nhấn!")

    pygame.display.flip()

pygame.quit()