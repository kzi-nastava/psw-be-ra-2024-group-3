INSERT INTO stakeholders."Achievements"("Id","ImagePath", "XpReward", "Type", "Name", "Description", "Status", "Criteria")
VALUES 
(-1,'assets/Review-Beginner.png', 10, 0, 'Review Beginner', 'Create 1 review', 0, 1),
(-2,'assets/Bronze-Reviewer.png', 30, 0, 'Bronze Reviewer', 'Create 5 reviews', 0, 5),
(-3,'assets/Silver-Reviewer.png', 70, 0, 'Silver Reviewer', 'Create 15 reviews', 0, 15),
(-4,'assets/Gold-Reviewer.png', 150, 0, 'Gold Reviewer', 'Create 30 reviews', 0, 30);

-- Achievements for PhotosInReview
INSERT INTO stakeholders."Achievements"("Id","ImagePath", "XpReward", "Type", "Name", "Description", "Status", "Criteria")
VALUES 
(-5,'assets/Bronze-Photographer.png', 10, 1, 'Bronze Photographer', 'Add 5 photos to a reviews', 0, 5),
(-6,'assets/Silver-Photographer.png', 25, 1, 'Silver Photographer', 'Add 50 photos to a reviews', 0, 50),
(-7,'assets/Gold-Photographer.png', 40, 1, 'Gold Photographer', 'Add 80 photos to a reviews', 0, 80);

-- Achievements for SocialEncounters
INSERT INTO stakeholders."Achievements"("Id","ImagePath", "XpReward", "Type", "Name", "Description", "Status", "Criteria")
VALUES 
(-8,'assets/Bronze-Socializer.png', 40, 2, 'Bronze Socializer', 'Complete 1 social encounter', 0, 1),
(-9,'assets/Silver-Socializer.png', 100, 2, 'Silver Socializer', 'Complete 10 social encounters', 0, 10),
(-10,'assets/Gold-Socializer.png', 180, 2, 'Gold Socializer', 'Complete 25 social encounters', 0, 25);

-- Achievements for SecretPlacesFound
INSERT INTO stakeholders."Achievements"("Id","ImagePath", "XpReward", "Type", "Name", "Description", "Status", "Criteria")
VALUES 
(-11,'assets/Explorer-Beginner.png', 40, 3, 'Explorer Beginner', 'Find 1 secret place', 0, 1),
(-12,'assets/Explorer-Intermediate.png', 80, 3, 'Explorer Intermediate', 'Find 5 secret places', 0, 5),
(-13,'assets/Explorer-Expert.png', 150, 3, 'Explorer Expert', 'Find 15 secret places', 0, 15);

-- Achievements for ChallengesCompleted
INSERT INTO stakeholders."Achievements"("Id","ImagePath", "XpReward", "Type", "Name", "Description", "Status", "Criteria")
VALUES 
(-14,'assets/Challenge-Beginner.png', 20, 4, 'Challenge Beginner', 'Complete 1 encounter', 0, 1),
(-15,'assets/Challenge-Skilled.png', 45, 4, 'Challenge Skilled', 'Complete 15 encounters', 0, 15),
(-16,'assets/Challenge-Master.png', 70, 4, 'Challenge Master', 'Complete 25 encounters', 0, 25);

-- Achievements for TourCompleted
INSERT INTO stakeholders."Achievements"("Id","ImagePath", "XpReward", "Type", "Name", "Description", "Status", "Criteria")
VALUES 
(-17,'assets/Tourist-Beginner.png', 25, 5, 'Tourist Beginner', 'Complete 1 tour', 0, 1),
(-18,'assets/Tourist-Explorer.png', 100, 5, 'Tourist Explorer', 'Complete 5 tours', 0, 5),
(-19,'assets/Tourist-Expert.png', 300, 5, 'Tourist Expert', 'Complete 20 tours', 0, 20);

-- Achievements for EnclountersCreated
INSERT INTO stakeholders."Achievements"("Id","ImagePath", "XpReward", "Type", "Name", "Description", "Status", "Criteria")
VALUES 
(-20,'assets/Bronze-Creator.png', 20, 6, 'Bronze Creator', 'Create 1 encounter', 0, 1),
(-21,'assets/Silver-Creator.png', 50, 6, 'Silver Creator', 'Create 5 encounters', 0, 5),
(-22,'assets/Gold-Creator.png', 100, 6, 'Gold Creator', 'Create 10 encounters', 0, 15);

-- Achievements for PointsEarned
INSERT INTO stakeholders."Achievements"("Id","ImagePath", "XpReward", "Type", "Name", "Description", "Status", "Criteria")
VALUES 
(-23,'assets/Points-Collector.png', 0, 7, 'Points Collector', 'Earn 100 points', 0, 100),
(-24,'assets/Points-Enthusiast.png', 0, 7, 'Points Enthusiast', 'Earn 500 points', 0, 500),
(-25,'assets/Points-Master.png', 0, 7, 'Points Master', 'Earn 1000 points', 0, 1000);
commit;