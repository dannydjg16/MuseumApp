-- Populate User
insert into [ArtApp].[User] (Email, Name, FromLocation) values ('danielgrant.joseph@gmail.com','Daniel Grant', 'Connecticut, United States');
insert into [ArtApp].[User] (Email, Name, FromLocation) values ('dannydsafjhha@gmail.com','Doniel Grant', 'Rhode Island, United States');

-- Populate Artist 
insert into [ArtApp].[Artist] (Name, Born, Died, BornLocation, Bio, PictureUrl) values ('Vincent van Gogh', '1853', '1890', 'Zundert, Netherlands', 'Vincent van Gogh (March 30, 1853 - July 29, 1890), Dutch painter and one of the greatest of the Post-Impressionists. The striking color, emphatic brushwork, and contoured forms of his work powerfully influenced the current of Expressionism in modern art. Van Gogh’s art became astoundingly popular after his death, especially in the late 20th century, when his work sold for record-breaking sums at auctions around the world and was featured in blockbuster touring exhibitions. ', 'https://www.reuters.com/resizer/5g0lht4m_D1RXj1eUgV4AELfZm4=/960x0/filters:quality(80)/cloudfront-us-east-2.images.arcpublishing.com/reuters/L5AGIMF57FIEHG3RIBWDWKHKXA.jpg');
-- Adding AdderID to the present Artists.
UPDATE [ArtApp].[Artist] SET ArtistAdderID = 1 WHERE ID = 2;

-- Populate Artwork 
insert into [ArtApp].[Artwork] (FileName, YearCreated, Title, Description, Likes, ArtistID, MediumID, LocationNow) values ('https://www.vangoghgallery.com/img/starry_night_full.jpg',1889,'The Starry Night','Inspired by the view from his window at the Saint-Paul-de-Mausole asylum in Saint-Rémy, in southern France, where the artist spent twelve months in 1889–90 seeking reprieve from his mental illnesses, The Starry Night (made in mid-June) is both an exercise in observation and a clear departure from it. The vision took place at night, yet the painting, among hundreds of artworks van Gogh made that year, was created in several sessions during the day, under entirely different atmospheric conditions. The picturesque village nestled below the hills was based on other views—it could not be seen from his window—and the cypress at left appears much closer than it was. And although certain features of the sky have been reconstructed as observed, the artist altered celestial shapes and added a sense of glow.',1,2,1,1);
-- Adding AdderID to the present Artworks. 
UPDATE [ArtApp].[Artwork] SET ArtWorkAdderID = 1 WHERE ID = 2
UPDATE [ArtApp].[Artwork] SET ArtWorkAdderID = 1 WHERE ID = 7
UPDATE [ArtApp].[Artwork] SET ArtWorkAdderID = 1 WHERE ID = 8

-- Populate ArtType
insert into [ArtApp].[ArtType] (Name, Description) values ('Painting', 'The history of painting reaches back in time to artifacts from pre-historic humans, and spans all cultures. It represents a continuous, though periodically disrupted, tradition from Antiquity. Across cultures, and spanning continents and millennia, the history of painting is an ongoing river of creativity, that continues into the 21st century. Until the early 20th century it relied primarily on representational, religious and classical motifs, after which time more purely abstract and conceptual approaches gained favor.');

-- Populate Location 
insert into [ArtApp].[Location] (LocationName, Description, LocationUrl, TypeID) values ('Museum of Modern Art', 'Founded in 1929, The Museum of Modern Art (MoMA) in midtown Manhattan was the first museum devoted to the modern era. Today MoMA’s rich and varied collection offers a panoramic overview of modern and contemporary art, from the innovative European painting and sculpture of the 1880s to today''s film, design, and performance art. From an initial gift of eight prints and one drawing, the collection has grown to include over 150,000 paintings, sculptures, drawings, prints, photographs, architectural models and drawings, and design objects; approximately 22,000 films and four million film stills; and, in its Library and Archives, over 300,000 books, artist books, and periodicals, and extensive individual files on more than 70,000 artists. Collection highlights include Claude Monet’s Water Lilies, Vincent van Gogh’s The Starry Night, and Pablo Picasso’s Les Demoiselles d''Avignon, along with more recent works by Andy Warhol, Elizabeth Murray, Cindy Sherman, and many others.', 'https://www.moma.org/',1);

-- Populate LocationType
insert into [ArtApp].[LocationType] (Name) values ('Museum');

-- Populate Likes
insert into [ArtApp].[Likes] (UserID, ArtID) values (1,2);

-- Delete Artwork accidentally added
DELETE FROM [ArtApp].[Artwork] WHERE ID = 19;

