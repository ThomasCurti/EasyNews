INSERT INTO event_type VALUES (null, "plague");
INSERT INTO event_type VALUES (null, "tsunami");
INSERT INTO event_type VALUES (null, "seisme");

INSERT INTO article_source VALUES (null, "AFP");
INSERT INTO article_source VALUES (null, "Reteurs");
INSERT INTO article_source VALUES (null, "FranceInfo");
INSERT INTO article_source VALUES (null, "Facebook");

INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Naissance du Coronavirus" as title,
           "Le coronavirus est une maladie qui est apparu en Chine dans la ville de Wuhan." as description,
           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor." as full_article,
           id as source_id
    FROM article_source
    WHERE name="AFP";
	
INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Coronavirus tue des gens" as title,
           "Le coronavirus est une maladie qui est apparu en Chine dans la ville de Wuhan." as description,
           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor. 
			Quisque suscipit cursus pellentesque. Sed tincidunt pellentesque velit id placerat. Curabitur a arcu accumsan, interdum erat at, congue nisl. In at molestie turpis, ac tristique metus. Morbi leo felis, consequat ut neque vitae, venenatis tristique elit. Praesent laoreet magna placerat, convallis enim eu, ultrices tellus. Ut pretium aliquet hendrerit. Morbi vestibulum odio congue neque commodo, sed lobortis dui luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 
			Ut placerat arcu ipsum, a auctor est pulvinar sit amet. Praesent pharetra mauris vitae tortor hendrerit efficitur. Morbi libero dolor, gravida eu elementum ac, ultrices eget leo. Sed pulvinar ligula quis odio sagittis tincidunt. Proin tincidunt pretium consectetur. Curabitur aliquam in sem sit amet ultricies. Fusce ultricies tristique lorem, non luctus quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis at lacus accumsan aliquam. 
			Phasellus dictum lorem id venenatis hendrerit. Sed porttitor risus turpis, a accumsan nulla vestibulum id. Quisque porta imperdiet lorem, sodales semper nisi molestie id. Maecenas eget suscipit purus, quis volutpat velit. Suspendisse venenatis erat in augue fringilla vestibulum tincidunt nec urna. Nullam porta auctor ex vitae placerat. Sed ullamcorper ut eros sed sodales. 
			Phasellus placerat diam diam, eget semper sapien accumsan in. Vestibulum eget ex lacus. Morbi sagittis lacinia urna, vitae lobortis augue efficitur sit amet. Aenean ultricies, tellus sit amet cursus rhoncus, lacus neque lobortis ligula, vitae rutrum orci tortor eu orci. Praesent lacus mi, viverra et lorem non, facilisis maximus tellus. Donec imperdiet hendrerit ultrices. Maecenas tempus mattis dapibus. Nunc ultricies magna lorem, at tincidunt enim elementum quis. Curabitur tempor auctor turpis, non ornare tellus. Morbi sit amet eleifend magna. Aenean dictum justo tellus, sit amet ullamcorper nisi luctus dapibus. Morbi vel magna at odio euismod dapibus quis a ligula. Nam eu orci pretium, blandit felis vel, feugiat lectus. " as full_article,
           id as source_id
    FROM article_source
    WHERE name="FranceInfo";
	
INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Coronavirus n'est pas gentil" as title,
           "Le coronavirus est une maladie qui est apparu en Chine dans la ville de Wuhan." as description,
           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor. 
			Quisque suscipit cursus pellentesque. Sed tincidunt pellentesque velit id placerat. Curabitur a arcu accumsan, interdum erat at, congue nisl. In at molestie turpis, ac tristique metus. Morbi leo felis, consequat ut neque vitae, venenatis tristique elit. Praesent laoreet magna placerat, convallis enim eu, ultrices tellus. Ut pretium aliquet hendrerit. Morbi vestibulum odio congue neque commodo, sed lobortis dui luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 
			Ut placerat arcu ipsum, a auctor est pulvinar sit amet. Praesent pharetra mauris vitae tortor hendrerit efficitur. Morbi libero dolor, gravida eu elementum ac, ultrices eget leo. Sed pulvinar ligula quis odio sagittis tincidunt. Proin tincidunt pretium consectetur. Curabitur aliquam in sem sit amet ultricies. Fusce ultricies tristique lorem, non luctus quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis at lacus accumsan aliquam. 
			Phasellus dictum lorem id venenatis hendrerit. Sed porttitor risus turpis, a accumsan nulla vestibulum id. Quisque porta imperdiet lorem, sodales semper nisi molestie id. Maecenas eget suscipit purus, quis volutpat velit. Suspendisse venenatis erat in augue fringilla vestibulum tincidunt nec urna. Nullam porta auctor ex vitae placerat. Sed ullamcorper ut eros sed sodales. 
			Phasellus placerat diam diam, eget semper sapien accumsan in. Vestibulum eget ex lacus. Morbi sagittis lacinia urna, vitae lobortis augue efficitur sit amet. Aenean ultricies, tellus sit amet cursus rhoncus, lacus neque lobortis ligula, vitae rutrum orci tortor eu orci. Praesent lacus mi, viverra et lorem non, facilisis maximus tellus. Donec imperdiet hendrerit ultrices. Maecenas tempus mattis dapibus. Nunc ultricies magna lorem, at tincidunt enim elementum quis. Curabitur tempor auctor turpis, non ornare tellus. Morbi sit amet eleifend magna. Aenean dictum justo tellus, sit amet ullamcorper nisi luctus dapibus. Morbi vel magna at odio euismod dapibus quis a ligula. Nam eu orci pretium, blandit felis vel, feugiat lectus. " as full_article,
           id as source_id
    FROM article_source
    WHERE name="Reteurs";
	
INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Coronavirus ça passe" as title,
           "Le coronavirus est une maladie qui est apparu en Inde dans la ville de Delhi." as description,
           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor. 
			Quisque suscipit cursus pellentesque. Sed tincidunt pellentesque velit id placerat. Curabitur a arcu accumsan, interdum erat at, congue nisl. In at molestie turpis, ac tristique metus. Morbi leo felis, consequat ut neque vitae, venenatis tristique elit. Praesent laoreet magna placerat, convallis enim eu, ultrices tellus. Ut pretium aliquet hendrerit. Morbi vestibulum odio congue neque commodo, sed lobortis dui luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 
			Ut placerat arcu ipsum, a auctor est pulvinar sit amet. Praesent pharetra mauris vitae tortor hendrerit efficitur. Morbi libero dolor, gravida eu elementum ac, ultrices eget leo. Sed pulvinar ligula quis odio sagittis tincidunt. Proin tincidunt pretium consectetur. Curabitur aliquam in sem sit amet ultricies. Fusce ultricies tristique lorem, non luctus quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis at lacus accumsan aliquam. 
			Phasellus dictum lorem id venenatis hendrerit. Sed porttitor risus turpis, a accumsan nulla vestibulum id. Quisque porta imperdiet lorem, sodales semper nisi molestie id. Maecenas eget suscipit purus, quis volutpat velit. Suspendisse venenatis erat in augue fringilla vestibulum tincidunt nec urna. Nullam porta auctor ex vitae placerat. Sed ullamcorper ut eros sed sodales. 
			Phasellus placerat diam diam, eget semper sapien accumsan in. Vestibulum eget ex lacus. Morbi sagittis lacinia urna, vitae lobortis augue efficitur sit amet. Aenean ultricies, tellus sit amet cursus rhoncus, lacus neque lobortis ligula, vitae rutrum orci tortor eu orci. Praesent lacus mi, viverra et lorem non, facilisis maximus tellus. Donec imperdiet hendrerit ultrices. Maecenas tempus mattis dapibus. Nunc ultricies magna lorem, at tincidunt enim elementum quis. Curabitur tempor auctor turpis, non ornare tellus. Morbi sit amet eleifend magna. Aenean dictum justo tellus, sit amet ullamcorper nisi luctus dapibus. Morbi vel magna at odio euismod dapibus quis a ligula. Nam eu orci pretium, blandit felis vel, feugiat lectus. " as full_article,
           id as source_id
    FROM article_source
    WHERE name="Facebook";
	


INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Tsunami ultra violent" as title,
           "blabla" as description,
           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor. 
			Quisque suscipit cursus pellentesque. Sed tincidunt pellentesque velit id placerat. Curabitur a arcu accumsan, interdum erat at, congue nisl. In at molestie turpis, ac tristique metus. Morbi leo felis, consequat ut neque vitae, venenatis tristique elit. Praesent laoreet magna placerat, convallis enim eu, ultrices tellus. Ut pretium aliquet hendrerit. Morbi vestibulum odio congue neque commodo, sed lobortis dui luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 
			Ut placerat arcu ipsum, a auctor est pulvinar sit amet. Praesent pharetra mauris vitae tortor hendrerit efficitur. Morbi libero dolor, gravida eu elementum ac, ultrices eget leo. Sed pulvinar ligula quis odio sagittis tincidunt. Proin tincidunt pretium consectetur. Curabitur aliquam in sem sit amet ultricies. Fusce ultricies tristique lorem, non luctus quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis at lacus accumsan aliquam. 
			Phasellus dictum lorem id venenatis hendrerit. Sed porttitor risus turpis, a accumsan nulla vestibulum id. Quisque porta imperdiet lorem, sodales semper nisi molestie id. Maecenas eget suscipit purus, quis volutpat velit. Suspendisse venenatis erat in augue fringilla vestibulum tincidunt nec urna. Nullam porta auctor ex vitae placerat. Sed ullamcorper ut eros sed sodales. 
			Phasellus placerat diam diam, eget semper sapien accumsan in. Vestibulum eget ex lacus. Morbi sagittis lacinia urna, vitae lobortis augue efficitur sit amet. Aenean ultricies, tellus sit amet cursus rhoncus, lacus neque lobortis ligula, vitae rutrum orci tortor eu orci. Praesent lacus mi, viverra et lorem non, facilisis maximus tellus. Donec imperdiet hendrerit ultrices. Maecenas tempus mattis dapibus. Nunc ultricies magna lorem, at tincidunt enim elementum quis. Curabitur tempor auctor turpis, non ornare tellus. Morbi sit amet eleifend magna. Aenean dictum justo tellus, sit amet ullamcorper nisi luctus dapibus. Morbi vel magna at odio euismod dapibus quis a ligula. Nam eu orci pretium, blandit felis vel, feugiat lectus. " as full_article,
           id as source_id
    FROM article_source
    WHERE name="AFP";
	
INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Tsunami tue des gens" as title,
           "blabla" as description,
           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor. 
			Quisque suscipit cursus pellentesque. Sed tincidunt pellentesque velit id placerat. Curabitur a arcu accumsan, interdum erat at, congue nisl. In at molestie turpis, ac tristique metus. Morbi leo felis, consequat ut neque vitae, venenatis tristique elit. Praesent laoreet magna placerat, convallis enim eu, ultrices tellus. Ut pretium aliquet hendrerit. Morbi vestibulum odio congue neque commodo, sed lobortis dui luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 
			Ut placerat arcu ipsum, a auctor est pulvinar sit amet. Praesent pharetra mauris vitae tortor hendrerit efficitur. Morbi libero dolor, gravida eu elementum ac, ultrices eget leo. Sed pulvinar ligula quis odio sagittis tincidunt. Proin tincidunt pretium consectetur. Curabitur aliquam in sem sit amet ultricies. Fusce ultricies tristique lorem, non luctus quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis at lacus accumsan aliquam. 
			Phasellus dictum lorem id venenatis hendrerit. Sed porttitor risus turpis, a accumsan nulla vestibulum id. Quisque porta imperdiet lorem, sodales semper nisi molestie id. Maecenas eget suscipit purus, quis volutpat velit. Suspendisse venenatis erat in augue fringilla vestibulum tincidunt nec urna. Nullam porta auctor ex vitae placerat. Sed ullamcorper ut eros sed sodales. 
			Phasellus placerat diam diam, eget semper sapien accumsan in. Vestibulum eget ex lacus. Morbi sagittis lacinia urna, vitae lobortis augue efficitur sit amet. Aenean ultricies, tellus sit amet cursus rhoncus, lacus neque lobortis ligula, vitae rutrum orci tortor eu orci. Praesent lacus mi, viverra et lorem non, facilisis maximus tellus. Donec imperdiet hendrerit ultrices. Maecenas tempus mattis dapibus. Nunc ultricies magna lorem, at tincidunt enim elementum quis. Curabitur tempor auctor turpis, non ornare tellus. Morbi sit amet eleifend magna. Aenean dictum justo tellus, sit amet ullamcorper nisi luctus dapibus. Morbi vel magna at odio euismod dapibus quis a ligula. Nam eu orci pretium, blandit felis vel, feugiat lectus. " as full_article,
           id as source_id
    FROM article_source
    WHERE name="FranceInfo";
	
INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Tsunami n'est pas gentil" as title,
           "blabla" as description,
           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor. 
			Quisque suscipit cursus pellentesque. Sed tincidunt pellentesque velit id placerat. Curabitur a arcu accumsan, interdum erat at, congue nisl. In at molestie turpis, ac tristique metus. Morbi leo felis, consequat ut neque vitae, venenatis tristique elit. Praesent laoreet magna placerat, convallis enim eu, ultrices tellus. Ut pretium aliquet hendrerit. Morbi vestibulum odio congue neque commodo, sed lobortis dui luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 
			Ut placerat arcu ipsum, a auctor est pulvinar sit amet. Praesent pharetra mauris vitae tortor hendrerit efficitur. Morbi libero dolor, gravida eu elementum ac, ultrices eget leo. Sed pulvinar ligula quis odio sagittis tincidunt. Proin tincidunt pretium consectetur. Curabitur aliquam in sem sit amet ultricies. Fusce ultricies tristique lorem, non luctus quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis at lacus accumsan aliquam. 
			Phasellus dictum lorem id venenatis hendrerit. Sed porttitor risus turpis, a accumsan nulla vestibulum id. Quisque porta imperdiet lorem, sodales semper nisi molestie id. Maecenas eget suscipit purus, quis volutpat velit. Suspendisse venenatis erat in augue fringilla vestibulum tincidunt nec urna. Nullam porta auctor ex vitae placerat. Sed ullamcorper ut eros sed sodales. 
			Phasellus placerat diam diam, eget semper sapien accumsan in. Vestibulum eget ex lacus. Morbi sagittis lacinia urna, vitae lobortis augue efficitur sit amet. Aenean ultricies, tellus sit amet cursus rhoncus, lacus neque lobortis ligula, vitae rutrum orci tortor eu orci. Praesent lacus mi, viverra et lorem non, facilisis maximus tellus. Donec imperdiet hendrerit ultrices. Maecenas tempus mattis dapibus. Nunc ultricies magna lorem, at tincidunt enim elementum quis. Curabitur tempor auctor turpis, non ornare tellus. Morbi sit amet eleifend magna. Aenean dictum justo tellus, sit amet ullamcorper nisi luctus dapibus. Morbi vel magna at odio euismod dapibus quis a ligula. Nam eu orci pretium, blandit felis vel, feugiat lectus. " as full_article,
           id as source_id
    FROM article_source
    WHERE name="Reteurs";
	
INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Tsunami ça passe" as title,
           "blabla" as description,
           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor. 
			Quisque suscipit cursus pellentesque. Sed tincidunt pellentesque velit id placerat. Curabitur a arcu accumsan, interdum erat at, congue nisl. In at molestie turpis, ac tristique metus. Morbi leo felis, consequat ut neque vitae, venenatis tristique elit. Praesent laoreet magna placerat, convallis enim eu, ultrices tellus. Ut pretium aliquet hendrerit. Morbi vestibulum odio congue neque commodo, sed lobortis dui luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 
			Ut placerat arcu ipsum, a auctor est pulvinar sit amet. Praesent pharetra mauris vitae tortor hendrerit efficitur. Morbi libero dolor, gravida eu elementum ac, ultrices eget leo. Sed pulvinar ligula quis odio sagittis tincidunt. Proin tincidunt pretium consectetur. Curabitur aliquam in sem sit amet ultricies. Fusce ultricies tristique lorem, non luctus quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis at lacus accumsan aliquam. 
			Phasellus dictum lorem id venenatis hendrerit. Sed porttitor risus turpis, a accumsan nulla vestibulum id. Quisque porta imperdiet lorem, sodales semper nisi molestie id. Maecenas eget suscipit purus, quis volutpat velit. Suspendisse venenatis erat in augue fringilla vestibulum tincidunt nec urna. Nullam porta auctor ex vitae placerat. Sed ullamcorper ut eros sed sodales. 
			Phasellus placerat diam diam, eget semper sapien accumsan in. Vestibulum eget ex lacus. Morbi sagittis lacinia urna, vitae lobortis augue efficitur sit amet. Aenean ultricies, tellus sit amet cursus rhoncus, lacus neque lobortis ligula, vitae rutrum orci tortor eu orci. Praesent lacus mi, viverra et lorem non, facilisis maximus tellus. Donec imperdiet hendrerit ultrices. Maecenas tempus mattis dapibus. Nunc ultricies magna lorem, at tincidunt enim elementum quis. Curabitur tempor auctor turpis, non ornare tellus. Morbi sit amet eleifend magna. Aenean dictum justo tellus, sit amet ullamcorper nisi luctus dapibus. Morbi vel magna at odio euismod dapibus quis a ligula. Nam eu orci pretium, blandit felis vel, feugiat lectus. " as full_article,
           id as source_id
    FROM article_source
    WHERE name="Facebook";
	
	
	
	
INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Seisme qui fait plein de dégat" as title,
           "blabla" as description,
           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor. 
			Quisque suscipit cursus pellentesque. Sed tincidunt pellentesque velit id placerat. Curabitur a arcu accumsan, interdum erat at, congue nisl. In at molestie turpis, ac tristique metus. Morbi leo felis, consequat ut neque vitae, venenatis tristique elit. Praesent laoreet magna placerat, convallis enim eu, ultrices tellus. Ut pretium aliquet hendrerit. Morbi vestibulum odio congue neque commodo, sed lobortis dui luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 
			Ut placerat arcu ipsum, a auctor est pulvinar sit amet. Praesent pharetra mauris vitae tortor hendrerit efficitur. Morbi libero dolor, gravida eu elementum ac, ultrices eget leo. Sed pulvinar ligula quis odio sagittis tincidunt. Proin tincidunt pretium consectetur. Curabitur aliquam in sem sit amet ultricies. Fusce ultricies tristique lorem, non luctus quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis at lacus accumsan aliquam. 
			Phasellus dictum lorem id venenatis hendrerit. Sed porttitor risus turpis, a accumsan nulla vestibulum id. Quisque porta imperdiet lorem, sodales semper nisi molestie id. Maecenas eget suscipit purus, quis volutpat velit. Suspendisse venenatis erat in augue fringilla vestibulum tincidunt nec urna. Nullam porta auctor ex vitae placerat. Sed ullamcorper ut eros sed sodales. 
			Phasellus placerat diam diam, eget semper sapien accumsan in. Vestibulum eget ex lacus. Morbi sagittis lacinia urna, vitae lobortis augue efficitur sit amet. Aenean ultricies, tellus sit amet cursus rhoncus, lacus neque lobortis ligula, vitae rutrum orci tortor eu orci. Praesent lacus mi, viverra et lorem non, facilisis maximus tellus. Donec imperdiet hendrerit ultrices. Maecenas tempus mattis dapibus. Nunc ultricies magna lorem, at tincidunt enim elementum quis. Curabitur tempor auctor turpis, non ornare tellus. Morbi sit amet eleifend magna. Aenean dictum justo tellus, sit amet ullamcorper nisi luctus dapibus. Morbi vel magna at odio euismod dapibus quis a ligula. Nam eu orci pretium, blandit felis vel, feugiat lectus. " as full_article,
           id as source_id
    FROM article_source
    WHERE name="AFP";
	
INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Seisme tue des gens" as title,
           "blabla" as description,
           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor. 
			Quisque suscipit cursus pellentesque. Sed tincidunt pellentesque velit id placerat. Curabitur a arcu accumsan, interdum erat at, congue nisl. In at molestie turpis, ac tristique metus. Morbi leo felis, consequat ut neque vitae, venenatis tristique elit. Praesent laoreet magna placerat, convallis enim eu, ultrices tellus. Ut pretium aliquet hendrerit. Morbi vestibulum odio congue neque commodo, sed lobortis dui luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 
			Ut placerat arcu ipsum, a auctor est pulvinar sit amet. Praesent pharetra mauris vitae tortor hendrerit efficitur. Morbi libero dolor, gravida eu elementum ac, ultrices eget leo. Sed pulvinar ligula quis odio sagittis tincidunt. Proin tincidunt pretium consectetur. Curabitur aliquam in sem sit amet ultricies. Fusce ultricies tristique lorem, non luctus quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis at lacus accumsan aliquam. 
			Phasellus dictum lorem id venenatis hendrerit. Sed porttitor risus turpis, a accumsan nulla vestibulum id. Quisque porta imperdiet lorem, sodales semper nisi molestie id. Maecenas eget suscipit purus, quis volutpat velit. Suspendisse venenatis erat in augue fringilla vestibulum tincidunt nec urna. Nullam porta auctor ex vitae placerat. Sed ullamcorper ut eros sed sodales. 
			Phasellus placerat diam diam, eget semper sapien accumsan in. Vestibulum eget ex lacus. Morbi sagittis lacinia urna, vitae lobortis augue efficitur sit amet. Aenean ultricies, tellus sit amet cursus rhoncus, lacus neque lobortis ligula, vitae rutrum orci tortor eu orci. Praesent lacus mi, viverra et lorem non, facilisis maximus tellus. Donec imperdiet hendrerit ultrices. Maecenas tempus mattis dapibus. Nunc ultricies magna lorem, at tincidunt enim elementum quis. Curabitur tempor auctor turpis, non ornare tellus. Morbi sit amet eleifend magna. Aenean dictum justo tellus, sit amet ullamcorper nisi luctus dapibus. Morbi vel magna at odio euismod dapibus quis a ligula. Nam eu orci pretium, blandit felis vel, feugiat lectus. " as full_article,
           id as source_id
    FROM article_source
    WHERE name="FranceInfo";
	
INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Seisme n'est pas gentil" as title,
           "blabla" as description,
           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor. 
			Quisque suscipit cursus pellentesque. Sed tincidunt pellentesque velit id placerat. Curabitur a arcu accumsan, interdum erat at, congue nisl. In at molestie turpis, ac tristique metus. Morbi leo felis, consequat ut neque vitae, venenatis tristique elit. Praesent laoreet magna placerat, convallis enim eu, ultrices tellus. Ut pretium aliquet hendrerit. Morbi vestibulum odio congue neque commodo, sed lobortis dui luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 
			Ut placerat arcu ipsum, a auctor est pulvinar sit amet. Praesent pharetra mauris vitae tortor hendrerit efficitur. Morbi libero dolor, gravida eu elementum ac, ultrices eget leo. Sed pulvinar ligula quis odio sagittis tincidunt. Proin tincidunt pretium consectetur. Curabitur aliquam in sem sit amet ultricies. Fusce ultricies tristique lorem, non luctus quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis at lacus accumsan aliquam. 
			Phasellus dictum lorem id venenatis hendrerit. Sed porttitor risus turpis, a accumsan nulla vestibulum id. Quisque porta imperdiet lorem, sodales semper nisi molestie id. Maecenas eget suscipit purus, quis volutpat velit. Suspendisse venenatis erat in augue fringilla vestibulum tincidunt nec urna. Nullam porta auctor ex vitae placerat. Sed ullamcorper ut eros sed sodales. 
			Phasellus placerat diam diam, eget semper sapien accumsan in. Vestibulum eget ex lacus. Morbi sagittis lacinia urna, vitae lobortis augue efficitur sit amet. Aenean ultricies, tellus sit amet cursus rhoncus, lacus neque lobortis ligula, vitae rutrum orci tortor eu orci. Praesent lacus mi, viverra et lorem non, facilisis maximus tellus. Donec imperdiet hendrerit ultrices. Maecenas tempus mattis dapibus. Nunc ultricies magna lorem, at tincidunt enim elementum quis. Curabitur tempor auctor turpis, non ornare tellus. Morbi sit amet eleifend magna. Aenean dictum justo tellus, sit amet ullamcorper nisi luctus dapibus. Morbi vel magna at odio euismod dapibus quis a ligula. Nam eu orci pretium, blandit felis vel, feugiat lectus. " as full_article,
           id as source_id
    FROM article_source
    WHERE name="Reteurs";
	
INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Seisme ça passe" as title,
           "blabla" as description,
           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor. 
			Quisque suscipit cursus pellentesque. Sed tincidunt pellentesque velit id placerat. Curabitur a arcu accumsan, interdum erat at, congue nisl. In at molestie turpis, ac tristique metus. Morbi leo felis, consequat ut neque vitae, venenatis tristique elit. Praesent laoreet magna placerat, convallis enim eu, ultrices tellus. Ut pretium aliquet hendrerit. Morbi vestibulum odio congue neque commodo, sed lobortis dui luctus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 
			Ut placerat arcu ipsum, a auctor est pulvinar sit amet. Praesent pharetra mauris vitae tortor hendrerit efficitur. Morbi libero dolor, gravida eu elementum ac, ultrices eget leo. Sed pulvinar ligula quis odio sagittis tincidunt. Proin tincidunt pretium consectetur. Curabitur aliquam in sem sit amet ultricies. Fusce ultricies tristique lorem, non luctus quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus venenatis at lacus accumsan aliquam. 
			Phasellus dictum lorem id venenatis hendrerit. Sed porttitor risus turpis, a accumsan nulla vestibulum id. Quisque porta imperdiet lorem, sodales semper nisi molestie id. Maecenas eget suscipit purus, quis volutpat velit. Suspendisse venenatis erat in augue fringilla vestibulum tincidunt nec urna. Nullam porta auctor ex vitae placerat. Sed ullamcorper ut eros sed sodales. 
			Phasellus placerat diam diam, eget semper sapien accumsan in. Vestibulum eget ex lacus. Morbi sagittis lacinia urna, vitae lobortis augue efficitur sit amet. Aenean ultricies, tellus sit amet cursus rhoncus, lacus neque lobortis ligula, vitae rutrum orci tortor eu orci. Praesent lacus mi, viverra et lorem non, facilisis maximus tellus. Donec imperdiet hendrerit ultrices. Maecenas tempus mattis dapibus. Nunc ultricies magna lorem, at tincidunt enim elementum quis. Curabitur tempor auctor turpis, non ornare tellus. Morbi sit amet eleifend magna. Aenean dictum justo tellus, sit amet ullamcorper nisi luctus dapibus. Morbi vel magna at odio euismod dapibus quis a ligula. Nam eu orci pretium, blandit felis vel, feugiat lectus. " as full_article,
           id as source_id
    FROM article_source
    WHERE name="Facebook";
	
	
INSERT INTO event VALUES
(null, 1, 1, "2020-03-02");

INSERT INTO event VALUES
(null, 1, 2, "2020-04-10");

INSERT INTO event VALUES
(null, 1, 3, "2020-03-11");

INSERT INTO event VALUES
(null, 1, 4, "2020-05-02");

INSERT INTO event VALUES
(null, 2, 5, "2020-01-02");

INSERT INTO event VALUES
(null, 2, 6, "2020-01-01");

INSERT INTO event VALUES
(null, 2, 7, "2020-02-02");

INSERT INTO event VALUES
(null, 2, 8, "2020-01-06");

INSERT INTO event VALUES
(null, 3, 9, "2020-08-08");

INSERT INTO event VALUES
(null, 3, 10, "2020-08-09");

INSERT INTO event VALUES
(null, 3, 11, "2020-09-10");

INSERT INTO event VALUES
(null, 3, 12, "2020-07-01");

INSERT INTO scenarios VALUES
(NULL, 1, "Coronavirus", 1, "2020/01/02", "Description de test coronavirus");

INSERT INTO scenarios VALUES
(NULL, 2, "Peste", 12, "600/01/02", "Description de test peste");

INSERT INTO scenarios VALUES
(NULL, 3, "Grippe espagnole", 3, "1600/01/02", "Description de test grippe");

