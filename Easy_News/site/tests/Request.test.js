const getFirstAlbumTitle = require('./Request');

it('returns all articles', async () => {
    const responseLength = await getFirstAlbumTitle();
    expect(responseLength).toEqual(12);
});