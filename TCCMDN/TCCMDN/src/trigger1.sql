/* test trigger */

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================================
-- Auteur :		Michael Duvoisin
-- Date :		24-11-2014
-- Description:	
--		Règles : 
--		1. Mot de passe entre 6 et 10 charactères
--		2. Au moins une majuscule
--		3. Au moins une minuscule
--		4. Au moins un chiffre
-- ================================================================
CREATE TRIGGER checkPassword 
   ON  [dbo].[credential] 
   AFTER UPDATE
AS 
BEGIN

	PRINT 'Début du trigger...'
	-- Variables fonctionnelles

	-- Contiendra les erreurs rencontrées
	DECLARE @errors NCHAR(255)
	SET @errors = '';

	-----------------------------------------------------------------------
	-- 0. Récupérer le mot de passe
	DECLARE @password NCHAR(255)
	SET @password = (SELECT password from inserted)
	-----------------------------------------------------------------------
	-- 1. Longueur

	DECLARE @length INT
	SET @length	= LEN(@password)
	PRINT '...test de la longueur : ' + CONVERT(NCHAR, @length) + ' charactères';
	-- PRINT 'Le mot de passe fait ' + CONVERT(NCHAR, @length) + ' charactères';

	IF @length <= 5 
		BEGIN
			SET @errors = @errors + 'Erreur : Password trop court (entre 6 et 10)'
			PRINT @errors
	END 

	IF @length >= 11 
		BEGIN
			SET @errors = @errors + 'Erreur : Password trop long (entre 6 et 10)'
			PRINT @errors
	END
	--------------------------------------------------------------------
	-- Boucle pour parcourir le password

	DECLARE @char NCHAR(1)
	DECLARE @nb_char_capital INT
	DECLARE @nb_char_normal INT
	DECLARE @nb_int INT
	DECLARE @i INT

	SET @nb_char_normal = 0
	SET @nb_char_capital = 0
	SET @nb_int = 0

	WHILE(@i < LEN(@password)+1)
       BEGIN

             --Récupére le caractère à la position @i
             SET @char = SUBSTRING(@password, @i, 1);

             -- Vérifie si c'est un caractère majuscule
             IF ((ASCII(@char) >= ASCII('A')) AND (ASCII(@char) <= ASCII('Z')))
				 SET @nb_char_capital = @nb_char_capital + 1;

             -- Vérifie si c'est un caractère minuscule
             IF ((ASCII(@char) >= ASCII('a')) AND (ASCII(@char) <= ASCII('z'))) 
				SET @nb_char_normal = @nb_char_normal + 1;

             -- Vérifie si c'est un chifre. incrémente le compteur de chiffres
             IF ((ASCII(@char) >= ASCII('1')) AND (ASCII(@char) <= ASCII('9')))
				 SET @nb_int = @nb_int + 1;

             SET @i = @i + 1
       END

	--------------------------------------------------------------------
	-- 2. Au moins une majuscule
	IF @nb_char_capital < 1 
		BEGIN
			SET @errors = @errors +  'Erreur : Le mot de passe doit contenir au moins une majsucule'
	END

	--------------------------------------------------------------------
	-- 3. Au moins une minuscule
	IF @nb_char_normal < 1 
		BEGIN
			SET @errors = @errors +  'Erreur : Le mot de passe doit contenir au moins une minuscule'
	END

	--------------------------------------------------------------------
	-- 4. Au moins un chiffre
	IF @nb_int < 1 
		BEGIN
			SET @errors = @errors +  'Erreur : Le mot de passe doit contenir au moins un chiffre'
	END

	--------------------------------------------------------------------
	-- Si aucune erreur trouvée :
	IF @errors = '' 
		BEGIN
			SET @errors =  @errors + 'Aucune erreur'
	END

	--------------------------------------------------------------------
	-- Afficher les erreurs :
	PRINT @errors + '...'
END
GO