const getFirstAlbumTitle = require('./Request');

it('returns all articles', async () => {
    const response = await getFirstAlbumTitle();
    expect(response.length).toEqual(12);
});

it('Get first article description', async () => {
    const response = await getFirstAlbumTitle();
    expect(response[0].description).toEqual("Le coronavirus est une maladie qui est apparu en Chine dans la ville de Wuhan.");
});

it('Get first article', async () => {
    const response = await getFirstAlbumTitle();
    expect(response[0].full_article).toEqual("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor.");
});